import {
  Component,
  OnInit,
  OnDestroy,
  OnChanges,
  SimpleChanges,
  Input,
  Output,
  EventEmitter,
} from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-shared-table',
  templateUrl: './shared-table.component.html',
  styleUrls: ['./shared-table.component.css'],
})
export class SharedTableComponent implements OnChanges, OnInit {
  displayedColumns = new Array<string>();
  dataSource = new MatTableDataSource<Object>();
  formControls: FormControl[];

  @Input() selectedRow: Object;
  // @Input() tableColumns: EnqTableColumn[];
  // @Input() tableConfiguration: EnqTableConfiguration;
  @Input() array: Array<Object>;
  @Output() selected = new EventEmitter();
  @Output() selectedColumn = new EventEmitter<Object>();

  constructor() {}

  ngOnChanges(changes: SimpleChanges): void {
    if (
      changes.array &&
      changes.array.currentValue !== changes.array.previousValue
    ) {
      this.dataSource.data = changes.array.currentValue;
    }
  }

  ngOnInit() {
    //this.displayedColumns = this.
  }
}
