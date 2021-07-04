import { Component, Inject, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { AutorModel } from "src/app/models/autor.model";
import { CONSTANTS } from "src/app/shared/constants";
import { OkCancelDialogComponent } from "src/app/shared/ok-cancel-dialog/ok-cancel-dialog.component";

interface IData {
  mode: string;
  data: AutorModel;
}

@Component({
  selector: "app-add-autor-dialog",
  templateUrl: "./add-autor-dialog.component.html",
  styleUrls: ["./add-autor-dialog.component.css"],
})
export class AddAutorDialogComponent implements OnInit {
  form: FormGroup;
  title: string;
  CONST = CONSTANTS.DETAIL_PAGE;

  constructor(
    private dialog: MatDialog,
    private dialogRef: MatDialogRef<AddAutorDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data: IData
  ) {
    this.title = `${
      data.mode == this.CONST.MODE.ADD
        ? this.CONST.ADICIONAR
        : this.CONST.EDITAR
    } Autor`;

    this.form = new FormGroup({
      nombre: new FormControl(data.data.nombre, [Validators.required]),
      fechaNacimiento: new FormControl(data.data.fechaNacimiento, [
        Validators.required,
      ]),
      ciudad: new FormControl(data.data.ciudad, [Validators.required]),
      correo: new FormControl(data.data.correo, [Validators.required]),
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
