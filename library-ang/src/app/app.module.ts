import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from "./app.component";
import { LibroComponent } from "./pages/libro/libro.component";
import { AutorComponent } from "./pages/autor/autor.component";
import { EditorialComponent } from "./pages/editorial/editorial.component";
import { AddLibroDialogComponent } from "./pages/libro/add-libro-dialog/add-libro-dialog.component";
import { AddEditorialDialogComponent } from "./pages/editorial/add-editorial-dialog/add-editorial-dialog.component";
import { AddAutorDialogComponent } from "./pages/autor/add-autor-dialog/add-autor-dialog.component";

import { AppRoutingModule } from "./app-routing.module";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { SharedModule } from "./shared/shared.module";
import { CoreModule } from "./core.module";

@NgModule({
  declarations: [
    AppComponent,
    LibroComponent,
    AutorComponent,
    EditorialComponent,
    AddLibroDialogComponent,
    AddAutorDialogComponent,
    AddEditorialDialogComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    CoreModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    AddLibroDialogComponent,
    AddAutorDialogComponent,
    AddEditorialDialogComponent,
  ],
})
export class AppModule {}
