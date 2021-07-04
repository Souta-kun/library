import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { of } from "rxjs";
import { environment } from "src/environments/environment";
import { EditorialModel } from "../models/editorial.model";
import { CONSTANTS } from "../shared/constants";

@Injectable({
  providedIn: "root",
})
export class EditorialService {
  constructor(private http: HttpClient) {}

  select() {
    return this.http.get<EditorialModel[]>(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Editorial}seleccionar`
    );
  }

  create(body: EditorialModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Editorial}adicionar`,
      body
    );
  }

  update(body: EditorialModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Editorial}editar`,
      body
    );
  }

  delete(id: number) {
    return this.http.delete(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Editorial}eliminar`,
      {
        params: new HttpParams().append("id", id.toString()),
      }
    );
  }
}
