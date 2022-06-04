import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { HelpDialogComponent } from '../components/help-dialog/help-dialog.component';

@Injectable()
export class HelpDialogService {
  constructor(protected dialog: MatDialog) { }

  showHelpDialog() {
    const dialogRef = this.dialog.open(HelpDialogComponent, {
      width: '1000px',
      height: '746px'
    });
  }
}
