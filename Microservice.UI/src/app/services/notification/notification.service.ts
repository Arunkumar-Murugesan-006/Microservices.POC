import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(public _snackbar: MatSnackBar) { }

  config: MatSnackBarConfig = 
  {
    duration: 3000,
    horizontalPosition: 'right',
    verticalPosition: 'top'
  }

  success(msg: string)
  {
    this.config['panelClass'] = ['notification', 'success'];
    this._snackbar.open(msg, '', this.config);
  }

  warn(msg: string)
  {
    this.config['panelClass'] = ['notification', 'warn'];
    this._snackbar.open(msg, '', this.config);
  }
}
