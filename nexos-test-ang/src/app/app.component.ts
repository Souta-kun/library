import { AfterViewInit, Component, OnInit } from "@angular/core";
import { MatIconRegistry } from "@angular/material";
import { DomSanitizer } from "@angular/platform-browser";
import { ActivatedRoute, Router } from "@angular/router";
import { NgxUiLoaderService } from "ngx-ui-loader";

import { CONSTANTS } from "./shared/constants";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
})
export class AppComponent implements OnInit {
  menu = CONSTANTS.MENU;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private iconRegistry: MatIconRegistry,
    private sanitizer: DomSanitizer
  ) {
    iconRegistry.addSvgIconLiteral(
      "plus",
      sanitizer.bypassSecurityTrustHtml(CONSTANTS.ICON.PLUS)
    );
    iconRegistry.addSvgIconLiteral(
      "pencil",
      sanitizer.bypassSecurityTrustHtml(CONSTANTS.ICON.PENCIL)
    );
    iconRegistry.addSvgIconLiteral(
      "trash",
      sanitizer.bypassSecurityTrustHtml(CONSTANTS.ICON.TRASH)
    );
    iconRegistry.addSvgIconLiteral(
      "close",
      sanitizer.bypassSecurityTrustHtml(CONSTANTS.ICON.CLOSE)
    );
    iconRegistry.addSvgIconLiteral(
      "cancel",
      sanitizer.bypassSecurityTrustHtml(CONSTANTS.ICON.CANCEL)
    );
  }

  ngOnInit() {}

  onRedirect(url: string) {
    this.router.navigate([url], { relativeTo: this.route });
  }
}
