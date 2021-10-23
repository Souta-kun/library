import { Component, Inject, OnInit } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";

interface IData {
  message: string;
  buttonMode: number;
}

@Component({
  selector: "app-ok-cancel-dialog",
  template: `
    <div mat-dialog-content>
      <p>{{ data.message }}</p>
    </div>
    <div style="text-align: right;">
      <button
        mat-stroked-button
        (click)="onOkClick()"
        color="primary"
        class="mr-2"
      >
        {{ yes }}
      </button>
      <button mat-raised-button (click)="onCancelClick()" color="primary">
        {{ no }}
      </button>
    </div>
  `,
})
export class OkCancelDialogComponent implements OnInit {
  yes: string;
  no: string;

  constructor(
    public dialogRef: MatDialogRef<OkCancelDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IData
  ) {
    switch (this.data.buttonMode) {
      case 0:
        this.yes = "Ok";
        this.no = "Cancel";
        break;

      case 1:
        this.yes = "Si";
        this.no = "No";
        break;

      case 2:
        this.yes = "OK";
        break;

      default:
        this.yes = "Ok";
        this.no = "Cancel";
        break;
    }
  }

  ngOnInit() {}

  onCancelClick(): void {
    this.dialogRef.close(false);
  }

  onOkClick(): void {
    this.dialogRef.close(true);
  }
}
