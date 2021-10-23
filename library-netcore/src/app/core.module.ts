import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import {
  MAT_DIALOG_DEFAULT_OPTIONS,
  MatDatepickerModule,
  MAT_DATE_LOCALE,
  MatPaginatorIntl,
} from "@angular/material";

export function CustomPaginator() {
  const customPaginatorIntl = new MatPaginatorIntl();

  customPaginatorIntl.itemsPerPageLabel = "Items por pagina:";

  return customPaginatorIntl;
}

@NgModule({
  providers: [
    MatDatepickerModule,
    { provide: MatPaginatorIntl, useValue: CustomPaginator() },
    { provide: MAT_DATE_LOCALE, useValue: "en-GB" },
    {
      provide: MAT_DIALOG_DEFAULT_OPTIONS,
      useValue: { hasBackdrop: true, disableClose: true },
    },
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class CoreModule {}
