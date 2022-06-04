import { DialogService } from './../../../../core/dialogs/services/dialog.service';
import { Component, OnDestroy } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormControl, Validators } from '@angular/forms';
import { SelectionModel } from '@angular/cdk/collections';
import { HelpReasons } from 'src/app/core/enums/help-reason.enum';
import { HelpDto } from '../../models/helpDto';
import { Subject } from 'rxjs';

@Component({
  selector: 'help-dialog',
  templateUrl: 'help-dialog.component.html',
  styleUrls: ['./help-dialog.component.css'],
})
export class HelpDialogComponent implements OnDestroy {
  helpReasons = HelpReasons;
  emailControl = new FormControl('', [Validators.required, Validators.email]);
  nameControl = new FormControl();
  hasError: boolean;
  selection = new SelectionModel<HelpReasons>(true, []);
  description = '';
  files = new Array<File>();
  fileNames = new Array<string>();
  fileList = new Array<string>();
  reasons = new Array<string>();
  destroy$ = new Subject<boolean>();

  constructor(
    public dialogRef: MatDialogRef<HelpDialogComponent>,
    private dialogService: DialogService
  ) {}

  ngOnDestroy(): void {
    this.destroy$.next(null);
    this.destroy$.unsubscribe();
  }

  public select(helpReason: HelpReasons): void {
    this.selection.isSelected(helpReason)
      ? this.selection.deselect(helpReason)
      : this.selection.select(helpReason);
  }

  public upload(): void {
    this.dialogService.browseFile().subscribe((filelist: FileList) => {
      if (filelist) {
        const file = filelist[0];
        this.files.push(file);
        this.fileNames.push(file.name);
        const reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = () => {
          this.fileList.push(`${reader.result}`);
        };
      }
    });
  }

  public submit(): void {
    this.hasError = false;
    if (!this.emailControl.valid || !this.selection.selected.length) {
      this.hasError = true;
      return;
    }
    const model = new HelpDto();
    model.username = this.nameControl.value;
    model.email = this.emailControl.value;
    this.selection.selected.forEach((reason: HelpReasons) => {
      let message = '';
      switch (reason) {
        case HelpReasons.ErrorMessage:
          message = 'CONTACT.R1';
          break;
        case HelpReasons.NotClear:
          message = 'CONTACT.R2';
          break;
        case HelpReasons.Report:
          message = 'CONTACT.R3';
          break;
        case HelpReasons.Idea:
          message = 'CONTACT.R4';
          break;
        default:
          break;
      }
      this.reasons.push(message);
    });

    model.reasons = this.reasons;
    model.description = this.description;
    model.files = this.fileList;
    model.filenames = this.fileNames;

    // this.organizationService
    //   .sendHelpForm(model)
    //   .subscribe((result: OperationStatus) => {
    //     if (result === OperationStatus.Success) {
    //       this.notificationService.showSuccessMessage('CONTACT.SUCCESS');
    //       this.dialogRef.close();
    //     } else {
    //       this.notificationService.showErrorMessage('CONTACT.ERROR-RESULT');
    //     }
    //   });
  }
}
