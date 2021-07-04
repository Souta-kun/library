import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

import {
  MatFormFieldModule,
  MatInputModule,
  MatCardModule,
  MatSelectModule,
  MatRadioModule,
  MatCheckboxModule,
  MatButtonModule,
  MatDialogModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatExpansionModule,
  MatAutocompleteModule,
  MatTooltipModule,
  MatPaginatorModule,
  MatTableModule,
  MatSortModule,
  MatTabsModule,
  MatIconModule,
} from "@angular/material";

import { NgxSpinnerModule } from "ngx-spinner";
import { ToastrModule } from "ngx-toastr";
import { NgxUiLoaderModule } from "ngx-ui-loader";
import "hammerjs";

import { OkCancelDialogComponent } from "./ok-cancel-dialog/ok-cancel-dialog.component";

@NgModule({
  declarations: [OkCancelDialogComponent],
  imports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    // material
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatSelectModule,
    MatRadioModule,
    MatCheckboxModule,
    MatButtonModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatExpansionModule,
    MatAutocompleteModule,
    MatTooltipModule,
    // features installed
    ToastrModule.forRoot(),
    NgxSpinnerModule,
    NgxUiLoaderModule,
  ],
  exports: [
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    // material
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatSelectModule,
    MatRadioModule,
    MatCheckboxModule,
    MatButtonModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatExpansionModule,
    MatAutocompleteModule,
    MatTooltipModule,
    MatPaginatorModule,
    MatTableModule,
    MatSortModule,
    MatTabsModule,
    MatIconModule,
    // features installed
    ToastrModule,
    NgxSpinnerModule,
    NgxUiLoaderModule,
  ],
  entryComponents: [OkCancelDialogComponent],
})
export class SharedModule {}
