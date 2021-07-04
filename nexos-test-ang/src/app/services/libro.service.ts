import { HttpClient } from "@angular/common/http";
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
    const l1 = new LibroModel();
    l1.titulo = "Alicia Wonderwold";
    l1.anio = 2010;
    l1.genero = "Fantasia";
    l1.npaginas = 17;
    l1.editorial = "Any";
    l1.autor = "Freddy Alexander Vargas Martinez";

    const l2 = new LibroModel();
    l2.titulo = "Underground";
    l2.anio = 2010;
    l2.genero = "Action";
    l2.npaginas = 17;
    l2.editorial = "Any";
    l2.autor = "David";

    const libros: LibroModel[] = [l1, l2];
    return of(libros);
    // return this.http.get<LibroModel[]>(
    //   `${environment.urlApi}${CONSTANTS.CONTROLLER.Editorial}Poselectst`
    // );
  }

  create(body: LibroModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Editorial}create`,
      body
    );
  }

  update(body: LibroModel) {
    return this.http.post(
      `${environment.urlApi}${CONSTANTS.CONTROLLER.Editorial}update`,
      body
    );
  }
}
