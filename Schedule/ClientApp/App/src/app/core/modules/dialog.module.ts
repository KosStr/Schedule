import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatListModule } from '@angular/material/list';
import { MatRadioModule } from '@angular/material/radio';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatTabsModule } from '@angular/material/tabs';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatSelectModule } from '@angular/material/select';
import { CdkTableModule } from '@angular/cdk/table';
import { DialogService } from '../dialogs/services/dialog.service';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { BrowseFileDialogComponent } from '../dialogs/components/browse-file-dialog';

@NgModule({
  imports: [
    MatDialogModule,
    CommonModule,
    HttpClientModule,
    FormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatTableModule,
    MatTabsModule,
    MatIconModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    MatDatepickerModule,
    MatRadioModule,
    MatPaginatorModule,
    MatSlideToggleModule,
    CdkTableModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MatListModule,
    MatAutocompleteModule,
  ],
  providers: [
    DialogService,
    {
      provide: MatDialogRef,
      useValue: {},
    },
  ],
  declarations: [BrowseFileDialogComponent],
})
export class DialogModule {}
