import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DialogService } from 'src/app/services/dialog/dialog.service';
import { NotificationService } from 'src/app/services/notification/notification.service';
import { ProductService } from 'src/app/services/product/product.service';
import { ProductComponent } from '../product/product.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  constructor(private _service: ProductService, 
              public _notification: NotificationService, 
              public _dialog: MatDialog,
              private _dialogService: DialogService) 
  {
    this._service.listen().subscribe((m: any) => 
    {
      this.fillGrid();
    });
  }

  grdlistData!: MatTableDataSource<any>;
  displayedColumns: string[] = ['productId','origin','destination','containerType','price','volume','actions']
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  searchKey! : string;

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
          this.grdlistData.sort = this.sort;
          this.grdlistData.paginator = this.paginator;
        }
      );
  }
  applyFilter()
  {
    this.grdlistData.filter = this.searchKey.trim().toLowerCase();
  }
  onSearchClear()
  {
    this.searchKey = "";
    this.applyFilter();
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
    this._dialogService.openConfirmDialog('Do you want to delete this record ' + id + ' ?')
      .afterClosed().subscribe(res => 
        {
          if(res)
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
        })
    
  }
}
