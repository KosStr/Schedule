import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { BrowseFileDialogComponent } from '../components/browse-file-dialog';

@Injectable()
export class DialogService {
  constructor(public dialog: MatDialog) { }

  public browseFile(): Observable<FileList> {
    let dialogRef: MatDialogRef<BrowseFileDialogComponent>;
    const config = {
      width: '600px',
      height: '150px'
    };
    dialogRef = this.dialog.open(BrowseFileDialogComponent, config);
    return dialogRef.afterClosed()
  }
}
