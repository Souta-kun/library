import { Component, Inject, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { LibroModel } from "src/app/models/libro.model";
import { CONSTANTS } from "src/app/shared/constants";
import { OkCancelDialogComponent } from "src/app/shared/ok-cancel-dialog/ok-cancel-dialog.component";

interface IData {
  mode: string;
  data: LibroModel;
}

@Component({
  selector: "app-add-libro-dialog",
  templateUrl: "./add-libro-dialog.component.html",
  styleUrls: ["./add-libro-dialog.component.css"],
})
export class AddLibroDialogComponent implements OnInit {
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
    } Libro`;

    this.form = new FormGroup({
      titulo: new FormControl(data.data.titulo, [Validators.required]),
      anio: new FormControl(data.data.anio, [Validators.required]),
      genero: new FormControl(data.data.genero, [Validators.required]),
      npaginas: new FormControl(data.data.npaginas, [Validators.required]),
      editorial: new FormControl(data.data.editorial, [Validators.required]),
      autor: new FormControl(data.data.autor, [Validators.required]),
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
