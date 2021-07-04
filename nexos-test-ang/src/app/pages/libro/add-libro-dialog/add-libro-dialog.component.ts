import { Component, Inject, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { ToastrService } from "ngx-toastr";
import { NgxUiLoaderService } from "ngx-ui-loader";
import { AutorModel } from "src/app/models/autor.model";
import { EditorialModel } from "src/app/models/editorial.model";
import { LibroModel } from "src/app/models/libro.model";
import { LibroService } from "src/app/services/libro.service";
import { CONSTANTS } from "src/app/shared/constants";
import { OkCancelDialogComponent } from "src/app/shared/ok-cancel-dialog/ok-cancel-dialog.component";

interface IData {
  mode: string;
  data: LibroModel;
  editoriales: EditorialModel[];
  autores: AutorModel[];
}

@Component({
  selector: "app-add-libro-dialog",
  templateUrl: "./add-libro-dialog.component.html",
  styleUrls: ["./add-libro-dialog.component.css"],
})
export class AddLibroDialogComponent implements OnInit {
  editoriales: EditorialModel[] = [];
  autores: AutorModel[] = [];
  form: FormGroup;
  title: string;
  CONST = CONSTANTS.DETAIL_PAGE;
  data: IData;

  constructor(
    private spinner: NgxUiLoaderService,
    private toastr: ToastrService,
    private libroService: LibroService,
    private dialog: MatDialog,
    private dialogRef: MatDialogRef<AddLibroDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: IData
  ) {
    this.data = data;
    this.editoriales = data.editoriales;
    this.autores = data.autores;
    this.title = `${
      data.mode == this.CONST.MODE.ADD
        ? this.CONST.ADICIONAR
        : this.CONST.EDITAR
    } Libro`;

    this.form = new FormGroup({
      titulo: new FormControl(data.data.titulo, [
        Validators.required,
        Validators.maxLength(150),
      ]),
      anio: new FormControl(data.data.anio, [
        Validators.required,
        Validators.min(0),
        Validators.max(9999),
      ]),
      genero: new FormControl(data.data.genero, [
        Validators.required,
        Validators.maxLength(150),
      ]),
      npaginas: new FormControl(data.data.npaginas, [
        Validators.required,
        Validators.min(1),
        Validators.max(2000000),
      ]),
      editorial: new FormControl(data.data.editorialId, [Validators.required]),
      autor: new FormControl(data.data.autorId, [Validators.required]),
    });
  }

  ngOnInit() {}

  onSalir() {
    this.dialogRef.close();
  }

  onSubmit() {
    const dialogRef = this.dialog.open(OkCancelDialogComponent, {
      width: "400px",
      height: "130px",
      data: {
        message: "¿Seguro desea guardar los cambios?",
        buttonMode: 1,
      },
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        let body = new LibroModel();
        body.id = this.data.data.id;
        body.anio = +this.form.value.anio;
        body.autorId = +this.form.value.autor;
        body.editorialId = +this.form.value.editorial;
        body.genero = this.form.value.genero;
        body.npaginas = +this.form.value.npaginas;
        body.titulo = this.form.value.titulo;

        if (this.data.mode == this.CONST.MODE.ADD) {
          this.libroService.create(body).subscribe(
            (result) => {
              this.toastr.success("Libro agregado");
              this.dialogRef.close(true);
            },
            (error) => {
              if (error.error.includes("MAXIMO_LIBRO_SUPERADO")) {
                this.toastr.warning(
                  "No es posible registrar el libro, se alcanzo el maximo permitido"
                );
                return;
              }
              this.toastr.error("Error creando Libro");
            }
          );
        } else {
          this.libroService.update(body).subscribe(
            (result) => {
              this.toastr.success("Libro actualizado");
              this.dialogRef.close(true);
            },
            (error) => {
              if (error.error.includes("MAXIMO_LIBRO_SUPERADO")) {
                this.toastr.warning(
                  "No es posible registrar el libro, se alcanzo el maximo permitido"
                );
                return;
              }
              if (error.error.includes("FK_Libro_Autor_Id")) {
                this.toastr.warning("El autor no esta registrado");
                return;
              }
              if (error.error.includes("FK_Editorial_Autor_Id")) {
                this.toastr.warning("La editorial no esta registrada");
                return;
              }
              this.toastr.error("Error actualizando libro");
            }
          );
        }
      }
    });
  }
}
