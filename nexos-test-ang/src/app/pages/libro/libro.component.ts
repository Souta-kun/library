import { Component, OnInit, ViewChild } from "@angular/core";
import {
  MatDialog,
  MatPaginator,
  MatSort,
  MatTableDataSource,
} from "@angular/material";

import { LibroModel } from "src/app/models/libro.model";
import { CONSTANTS } from "src/app/shared/constants";

import { NgxUiLoaderService } from "ngx-ui-loader";
import { ToastrService } from "ngx-toastr";
import { LibroService } from "src/app/services/libro.service";

import { OkCancelDialogComponent } from "src/app/shared/ok-cancel-dialog/ok-cancel-dialog.component";
import { AddLibroDialogComponent } from "./add-libro-dialog/add-libro-dialog.component";

@Component({
  selector: "app-libro",
  templateUrl: "./libro.component.html",
  styleUrls: ["./libro.component.css"],
})
export class LibroComponent implements OnInit {
  displayedColumns: string[] = [
    "titulo",
    "anio",
    "genero",
    "npaginas",
    "editorial",
    "autor",
    "actions",
  ];
  dataSource: MatTableDataSource<LibroModel> = new MatTableDataSource([]);

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private spinner: NgxUiLoaderService,
    private toastr: ToastrService,
    private dialog: MatDialog,
    private libroService: LibroService
  ) {}

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.consultar();
  }

  consultar() {
    this.spinner.start();
    this.libroService.select().subscribe(
      (result) => {
        this.spinner.stop();
        this.dataSource.data = result;
      },
      (error) => {
        this.spinner.stop();
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
    const dialog = this.dialog.open(AddLibroDialogComponent, {
      width: "300px",
      height: "auto",
      data: { mode: CONSTANTS.DETAIL_PAGE.MODE.ADD, data: new LibroModel() },
    });

    dialog.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.consultar();
      }
    });
  }

  onEdit(row: LibroModel) {
    const dialog = this.dialog.open(AddLibroDialogComponent, {
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

  onDelete(row: LibroModel) {
    const dialogRef = this.dialog.open(OkCancelDialogComponent, {
      width: "400px",
      height: "130px",
      data: {
        message: "¿Seguro desea eliminar el libro?",
        buttonMode: 1,
      },
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.toastr.success("Libro eliminado.");
        this.consultar();
      }
    });
  }
}
