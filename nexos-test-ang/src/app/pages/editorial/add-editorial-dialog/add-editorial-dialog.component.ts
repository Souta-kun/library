import { Component, OnInit, Inject } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { EditorialModel } from "src/app/models/editorial.model";
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

  constructor(
    private dialog: MatDialog,
    private dialogRef: MatDialogRef<AddLibroDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: IData
  ) {
    this.title = `${
      data.mode == this.CONST.MODE.ADD
        ? this.CONST.ADICIONAR
        : this.CONST.EDITAR
    } Editorial`;

    this.form = new FormGroup({
      nombre: new FormControl(data.data.nombre, [Validators.required]),
      direccionCorrespondencia: new FormControl(
        data.data.direccionCorrespondencia,
        [Validators.required]
      ),
      telefono: new FormControl(data.data.telefono, [Validators.required]),
      correo: new FormControl(data.data.correo, [Validators.required]),
      maxLibroRegistrado: new FormControl(data.data.maxLibroRegistrado, [
        Validators.required,
      ]),
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
      }
    });
  }
}
