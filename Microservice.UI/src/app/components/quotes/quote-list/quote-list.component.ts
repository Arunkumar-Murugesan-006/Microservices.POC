import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/services/notification/notification.service';
import { QuoteService } from 'src/app/services/quote/quote.service';
import { QuoteComponent } from '../quote/quote.component';

@Component({
  selector: 'app-quote-list',
  templateUrl: './quote-list.component.html',
  styleUrls: ['./quote-list.component.css']
})
export class QuoteListComponent implements OnInit {

  constructor(private _service: QuoteService, public _notification: NotificationService, public _dialog: MatDialog) 
  { 
    this._service.listen().subscribe((m: any) => 
    {
      this.fillGrid();
    });
  }

  grdlistData!: MatTableDataSource<any>;
  displayedColumns: string[] = ['origin','destination','containerType','quotePrice']

  ngOnInit(): void 
  {
    this.fillGrid();
  }
  fillGrid()
  {
    this._service.getAllQuotes()
      .subscribe(
        data => 
        {
          this.grdlistData = new MatTableDataSource(data);
        }
      );
  }
  onCreate()
  {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "30%";
    this._dialog.open(QuoteComponent, dialogConfig);
  }
  onEdit(quote: any)
  {
    
  }

  onDelete(id: any)
  {
    
  }
}
