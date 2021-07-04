import { Component, OnInit, ViewChild } from "@angular/core";
import {
  MatDialog,
  MatPaginator,
  MatSort,
  MatTableDataSource,
} from "@angular/material";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { AutorModel } from "src/app/models/autor.model";
import { AutorService } from "src/app/services/autor.service";
import { CONSTANTS } from "src/app/shared/constants";
import { OkCancelDialogComponent } from "src/app/shared/ok-cancel-dialog/ok-cancel-dialog.component";
import { AddAutorDialogComponent } from "./add-autor-dialog/add-autor-dialog.component";

@Component({
  selector: "app-autor",
  templateUrl: "./autor.component.html",
  styleUrls: ["./autor.component.css"],
})
export class AutorComponent implements OnInit {
  displayedColumns: string[] = [
    "nombre",
    "fechaNacimiento",
    "ciudad",
    "correo",
    "actions",
  ];
  dataSource: MatTableDataSource<AutorModel> = new MatTableDataSource([]);

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private spinnerService: NgxSpinnerService,
    private toastr: ToastrService,
    private dialog: MatDialog,
    private autorService: AutorService
  ) {}

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.consultar();
  }

  consultar() {
    this.spinnerService.show();
    this.autorService.select().subscribe(
      (result) => {
        this.spinnerService.hide();
        this.dataSource.data = result;
      },
      (error) => {
        this.spinnerService.hide();
        this.toastr.error("Error consultando datos.");
      }
    );
  }

  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  onAdd() {
    const dialog = this.dialog.open(AddAutorDialogComponent, {
      width: "300px",
      height: "auto",
      data: { mode: CONSTANTS.DETAIL_PAGE.MODE.ADD, data: new AutorModel() },
    });

    dialog.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.consultar();
      }
    });
  }

  onEdit(row: AutorModel) {
    const dialog = this.dialog.open(AddAutorDialogComponent, {
      width: "300px",
      height: "auto",
      data: { mode: CONSTANTS.DETAIL_PAGE.MODE.EDIT, data: row },
    });

    dialog.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.consultar();
      }
    });
  }

  onDelete(row: AutorModel) {
    const dialogRef = this.dialog.open(OkCancelDialogComponent, {
      width: "400px",
      height: "130px",
      data: {
        message: "¿Seguro desea eliminar el autor?",
        buttonMode: 1,
      },
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.consultar();
      }
    });
  }
}
