import { Component, OnInit, Inject } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { ToastrService } from "ngx-toastr";
import { NgxUiLoaderService } from "ngx-ui-loader";
import { EditorialModel } from "src/app/models/editorial.model";
import { EditorialService } from "src/app/services/editorial.service";
import { CONSTANTS } from "src/app/shared/constants";
import { OkCancelDialogComponent } from "src/app/shared/ok-cancel-dialog/ok-cancel-dialog.component";
import { AddLibroDialogComponent } from "../../libro/add-libro-dialog/add-libro-dialog.component";

interface IData {
  mode: string;
  data: EditorialModel;
}

@Component({
  selector: "app-add-editorial-dialog",
  templateUrl: "./add-editorial-dialog.component.html",
  styleUrls: ["./add-editorial-dialog.component.css"],
})
export class AddEditorialDialogComponent implements OnInit {
  form: FormGroup;
  title: string;
  CONST = CONSTANTS.DETAIL_PAGE;
  data: IData;

  constructor(
    private spinner: NgxUiLoaderService,
    private toastr: ToastrService,
    private editorialService: EditorialService,
    private dialog: MatDialog,
    private dialogRef: MatDialogRef<AddLibroDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: IData
  ) {
    this.data = data;
    this.title = `${
      data.mode == this.CONST.MODE.ADD
        ? this.CONST.ADICIONAR
        : this.CONST.EDITAR
    } Editorial`;

    this.form = new FormGroup({
      nombre: new FormControl(data.data.nombre, [
        Validators.required,
        Validators.maxLength(250),
      ]),
      direccionCorrespondencia: new FormControl(
        data.data.direccionCorrespondencia,
        [Validators.required, Validators.maxLength(250)]
      ),
      telefono: new FormControl(data.data.telefono, [
        Validators.required,
        Validators.maxLength(15),
      ]),
      correo: new FormControl(data.data.correo, [
        Validators.required,
        Validators.maxLength(150),
      ]),
      maxLibroRegistrado: new FormControl(data.data.maxLibroRegistrado, [
        Validators.required,
        Validators.min(-1),
        Validators.max(2000000),
      ]),
    });
  }

  ngOnInit() {}

  onSalir() {
    this.dialogRef.close(false);
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
        let body = new EditorialModel();
        body.id = this.data.data.id;
        body.correo = this.form.value.correo;
        body.direccionCorrespondencia =
          this.form.value.direccionCorrespondencia;
        body.maxLibroRegistrado = +this.form.value.maxLibroRegistrado;
        body.nombre = this.form.value.nombre;
        body.telefono = this.form.value.telefono;

        if (this.data.mode == this.CONST.MODE.ADD) {
          this.editorialService.create(body).subscribe(
            (result) => {
              this.toastr.success("Editorial agregada");
              this.dialogRef.close(true);
            },
            (error) => {
              this.toastr.error("Error creando Editorial");
            }
          );
        } else {
          this.editorialService.update(body).subscribe(
            (result) => {
              this.toastr.success("Editorial actualizada");
              this.dialogRef.close(true);
            },
            (error) => {
              this.toastr.error("Error actualizando Editorial");
            }
          );
        }
      }
    });
  }
}
