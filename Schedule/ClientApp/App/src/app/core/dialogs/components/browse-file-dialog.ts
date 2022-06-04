import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'browse-file-dialog',
  templateUrl: './browse-file-dialog.html',
  styleUrls: ['./browse-file-dialog.css']
})
export class BrowseFileDialogComponent {
  constructor(public dialogRef: MatDialogRef<BrowseFileDialogComponent>) { }

  // handleFileInput(files: FileList) {
  //   return this.dialogRef.close(files);
  // }
  handleFileInput() {}
}
