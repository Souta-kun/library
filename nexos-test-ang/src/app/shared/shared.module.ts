import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
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
  MatPaginatorIntl,
  MAT_DIALOG_DEFAULT_OPTIONS,
  MAT_DATE_LOCALE,
} from "@angular/material";

import { OkCancelDialogComponent } from "./ok-cancel-dialog/ok-cancel-dialog.component";

import { NgxSpinnerModule } from "ngx-spinner";
import { ToastrModule } from "ngx-toastr";
import "hammerjs";

export function CustomPaginator() {
  const customPaginatorIntl = new MatPaginatorIntl();
  customPaginatorIntl.itemsPerPageLabel = "Items por pagina:";
  return customPaginatorIntl;
}

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
    NgxSpinnerModule,
    ToastrModule.forRoot(),
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
  ],
  entryComponents: [OkCancelDialogComponent],
  providers: [
    { provide: MatPaginatorIntl, useValue: CustomPaginator() },
    {
      provide: MAT_DIALOG_DEFAULT_OPTIONS,
      useValue: { hasBackdrop: true, disableClose: true },
    },
    { provide: MAT_DATE_LOCALE, useValue: "en-GB" },
  ],
})
export class SharedModule {}
