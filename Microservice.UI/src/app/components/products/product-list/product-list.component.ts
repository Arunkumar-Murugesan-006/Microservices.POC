import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { NotificationService } from 'src/app/services/notification/notification.service';
import { ProductService } from 'src/app/services/product/product.service';
import { ProductComponent } from '../product/product.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(private _service: ProductService, public _notification: NotificationService, public _dialog: MatDialog) 
  {
    this._service.listen().subscribe((m: any) => 
    {
      this.fillGrid();
    });
  }

  grdlistData!: MatTableDataSource<any>;
  displayedColumns: string[] = ['origin','destination','containerType','price','volume','actions']

  ngOnInit(): void 
  {
    this.fillGrid();
  }
  
  fillGrid()
  {
    this._service.getAllProducts()
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
    this._dialog.open(ProductComponent, dialogConfig);
  }

  onEdit(product: any)
  {
    this._service.populateForm(product);    
    
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "30%";
    this._dialog.open(ProductComponent, dialogConfig);
    this._notification.success("You clicked edit!");
  }

  onDelete(id: any)
  {
    this._service.deleteProduct(id)
      .subscribe(
        data => 
        {
          this._notification.warn("Record Deleted Successfully!!");
          this._service.filter('');
        }
      )
  }

}
