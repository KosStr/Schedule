import { SharedTableComponent } from './../configurations/shared-table/shared-table/shared-table.component';
import { DragDropModule } from "@angular/cdk/drag-drop";
import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatAutocompleteModule } from "@angular/material/autocomplete";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatTableModule } from "@angular/material/table";
import { MatTooltipModule } from "@angular/material/tooltip";

@NgModule({
  imports: [
    MatTableModule,
    CommonModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatAutocompleteModule,
    DragDropModule,
    MatPaginatorModule,
    MatTooltipModule,
    MatCheckboxModule,
    FormsModule,
  ],
  declarations: [
    SharedTableComponent
  ],
  providers: [],
  entryComponents: [],
  exports: [
  ],
})
export class SharedModule {}
