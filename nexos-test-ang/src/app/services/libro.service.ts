import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { of } from "rxjs";
import { environment } from "src/environments/environment";
import { LibroModel } from "../models/libro.model";
import { CONSTANTS } from "../shared/constants";

@Injectable({
  providedIn: "root",
})
export class LibroService {
  constructor(private http: HttpClient) {}

  select() {
    return this.http.get<LibroModel[]>(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Libro}seleccionar`
    );
  }

  create(body: LibroModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Libro}adicionar`,
      body
    );
  }

  update(body: LibroModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Libro}editar`,
      body
    );
  }

  delete(id: number) {
    return this.http.delete(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Libro}eliminar`,
      {
        params: new HttpParams().append("id", id.toString()),
      }
    );
  }
}
