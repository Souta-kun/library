import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AutorComponent } from "./pages/autor/autor.component";
import { EditorialComponent } from "./pages/editorial/editorial.component";
import { LibroComponent } from "./pages/libro/libro.component";

const routes: Routes = [
  { path: "libro", component: LibroComponent },
  { path: "autor", component: AutorComponent },
  { path: "editorial", component: EditorialComponent },
  { path: "**", redirectTo: "/libro", pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
