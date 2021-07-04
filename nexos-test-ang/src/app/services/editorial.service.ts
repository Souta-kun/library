import { HttpClient } from "@angular/common/http";
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
    const l1 = new EditorialModel();
    l1.nombre = "LOS CASAS";
    l1.direccionCorrespondencia = "Cl 21. #65-30";
    l1.telefono = "(5) 6765815";
    l1.correo = "test@gmail.com";
    l1.maxLibroRegistrado = 10;

    const l2 = new EditorialModel();
    l2.nombre = "NUEVO MUNDO";
    l2.direccionCorrespondencia = "Cl 21. #65-30";
    l2.telefono = "(5) 6765815";
    l2.correo = "test@gmail.com";
    l2.maxLibroRegistrado = 21;

    const editoriales: EditorialModel[] = [l1, l2];
    return of(editoriales);
    // return this.http.get<EditorialModel[]>(
    //   `${environment.urlApi}${CONSTANTS.CONTROLLER.Editorial}Poselectst`
    // );
  }

  create(body: EditorialModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Editorial}create`,
      body
    );
  }

  update(body: EditorialModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Editorial}update`,
      body
    );
  }
}
