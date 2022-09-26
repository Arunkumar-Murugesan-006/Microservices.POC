import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-mat-confirm-dialog',
  templateUrl: './mat-confirm-dialog.component.html',
  styleUrls: ['./mat-confirm-dialog.component.css']
})
export class MatConfirmDialogComponent implements OnInit {

  
  constructor(@Inject(MAT_DIALOG_DATA) public data : 
  {
                  cancelText: string,
                  confirmText: string,
                  message: string,
                  title: string
  }, public _dialogRef : MatDialogRef<MatConfirmDialogComponent>) { }
  // constructor(@Inject(MAT_DIALOG_DATA) public data, 
  // public _dialogRef : MatDialogRef<MatConfirmDialogComponent>) 
  // { 

  // }


  ngOnInit(): void {
  }

  closeDialog()
  {
    this._dialogRef.close(false);
  }

}
