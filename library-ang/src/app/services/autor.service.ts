import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { of } from "rxjs";
import { environment } from "src/environments/environment";
import { AutorModel } from "../models/autor.model";
import { CONSTANTS } from "../shared/constants";

@Injectable({
  providedIn: "root",
})
export class AutorService {
  constructor(private http: HttpClient) {}

  select() {
    return this.http.get<AutorModel[]>(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Autor}seleccionar`
    );
  }

  create(body: AutorModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Autor}adicionar`,
      body
    );
  }

  update(body: AutorModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Autor}editar`,
      body
    );
  }

  delete(id: number) {
    return this.http.delete(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Autor}eliminar`,
      {
        params: new HttpParams().append("id", id.toString()),
      }
    );
  }
}
