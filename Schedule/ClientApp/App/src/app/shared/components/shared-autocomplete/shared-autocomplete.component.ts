import {
  Component,
  EventEmitter,
  Input,
  OnChanges,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatAutocompleteTrigger } from '@angular/material/autocomplete';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { SharedAutocompleteConfiguration } from './shared-autocomplete.configuration';

@Component({
  selector: 'shared-autocomplete',
  templateUrl: './shared-autocomplete.component.html',
  styleUrls: ['./shared-autocomplete.component.scss'],
})
export class SharedAutocompleteComponent implements OnInit, OnChanges {
  selectControl = new FormControl('');
  filteredValues = new Observable<Array<Object>>();

  @Input() selectedValues = new Array<Object>();
  @Input() array: Array<Object>;
  @Input() label: string;
  @Input() configuration: SharedAutocompleteConfiguration;
  @Input() selectedValue: Object;
  @Input() placeholder: string = '';
  @Output() selected = new EventEmitter();
  @Output() multipleSelected = new EventEmitter<Array<Object>>();

  @ViewChild('autoCompleteInput', { read: MatAutocompleteTrigger })
  autoCompleteInput: MatAutocompleteTrigger;

  constructor() {}

  ngOnInit(): void {
    if (this.selectedValue || this.selectedValues?.length) {
      if (this.configuration?.displayMultiple) {
        this.selectControl.setValue(
          this.selectedValues
            .map((ms) =>
              this.configuration.displayedProperties.map((p) => ms[p]).join(' ')
            )
            .join(', ')
        );
      } else {
        this.selectControl.setValue(
          this.configuration?.displayedProperties
            .map((p) => this.selectedValue[p])
            .join(' ')
        );
      }
    }
    this.filteredValues = this.selectControl.valueChanges.pipe(
      map((value) => this.filter(value))
    );
  }

  ngOnChanges(): void {
    if (!this.selectedValues?.length && !this.selectedValue) {
      this.selectControl.setValue('');
    } else if (this.selectedValues?.length) {
      this.selectControl.setValue(
        this.selectedValues
          .map((ms) =>
            this.configuration.displayedProperties.map((p) => ms[p]).join(' ')
          )
          .join(', ')
      );
    }
    if (this.selectedValue) {
      this.selectControl.setValue(this.getOptionValue(this.selectedValue));
    }
    if (!this.selectControl.value) {
      this.selectControl.setValue('');
    }
    if (!this.configuration?.displayMultiple) {
      this.selectedValues = new Array<Object>();
    }
  }

  public setValue(): void {
    if (!this.selectControl.value) {
      this.selectControl.setValue('');
    }
    if (this.configuration?.displayMultiple) {
      this.filteredValues = of(this.array);
      this.autoCompleteInput.openPanel();
    }
  }

  public select(row: Object): void {
    if (!this.selectedValues) {
      this.selectControl.setValue('');
      return;
    }
    if (!this.configuration?.multiple) {
      this.selected.emit(row);
    } else {
      this.selectedValues.some((x) => this.configuration.itemComparer(row, x))
        ? (this.selectedValues = this.selectedValues.filter(
            (x) => !this.configuration.itemComparer(row, x)
          ))
        : this.selectedValues.push(row);
      if (this.configuration?.displayMultiple) {
        this.selectControl.setValue(
          this.selectedValues
            .map((ms) =>
              this.configuration.displayedProperties.map((p) => ms[p]).join(' ')
            )
            .join(', ')
        );
      } else {
        this.selectControl.setValue('');
      }
      this.autoCompleteInput.openPanel();
    }
  }

  public selectMultiple(): void {
    this.multipleSelected.emit(this.selectedValues);
    if (this.configuration?.displayMultiple) {
      this.selectControl.setValue(
        this.selectedValues
          .map((ms) =>
            this.configuration.displayedProperties.map((p) => ms[p]).join(' ')
          )
          .join(', ')
      );
    }
    if (!this.configuration?.displayMultiple) {
      this.selectedValues = new Array<Object>();
    }
    this.autoCompleteInput.closePanel();
  }

  public isSelected(option: Object): boolean {
    if (this.selectedValues?.length) {
      return this.selectedValues.some((x) =>
        this.configuration.itemComparer(option, x)
      );
    }
  }

  public getOptionValue(row: Object): string {
    if (this.configuration.displayedProperties?.length) {
      return this.configuration.displayedProperties
        .map((p) => row[p])
        .join(' ');
    }
    return `${row}`;
  }

  private filter(value: string): Array<Object> {
    if (this.array) {
      return this.array.filter(
        (opt) =>
          this.configuration?.displayedProperties.map((p) =>
            opt[p]?.toLowerCase().includes(value.toLowerCase())
          )[0]
      );
    }
  }
}
