import { HttpClient } from "@angular/common/http";
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
    const l1 = new AutorModel();
    l1.nombre = "Freddy Vargas";
    l1.fechaNacimiento = new Date();
    l1.ciudad = "Cartagena";
    l1.correo = "test@gmail.com";

    const l2 = new AutorModel();
    l2.nombre = "Alexander Martinez";
    l2.fechaNacimiento = new Date();
    l2.ciudad = "Bogota";
    l2.correo = "test@gmail.com";

    const autores: AutorModel[] = [l1, l2];
    return of(autores);
    // return this.http.get<AutorModel[]>(
    //   `${environment.urlApi}${CONSTANTS.CONTROLLER.Autor}Poselectst`
    // );
  }

  create(body: AutorModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Autor}create`,
      body
    );
  }

  update(body: AutorModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Autor}update`,
      body
    );
  }
}
