import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { ProductModel } from 'src/app/models/product/product.model';
import { NotificationService } from 'src/app/services/notification/notification.service';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(public _service: ProductService, 
              public _dialogRef: MatDialogRef<ProductComponent>,
              public _notification: NotificationService) { }

  ngOnInit(): void {
  }
  onClose()
  {
    this._service.form.reset();
    this._service.initializeFormGroup();
    this._dialogRef.close();
    this._service.filter('');
  }
  onClear()
  {
    this._service.form.reset();
    this._service.initializeFormGroup();
  }
  onSubmit()
  {
    var product = new ProductModel();
    product.origin = this._service.form.value["origin"];
    product.destination = this._service.form.value["destination"];
    product.containerType = this._service.form.value["containerType"];
    product.price = this._service.form.value["price"];
    product.volume = this._service.form.value["volume"];

    this._service.addProduct(product)
      .subscribe
      (
        data => 
        {
          this._service.form.reset();
          this._service.initializeFormGroup();
          this._notification.success("Record Submitted Successfully!!")
          this.onClose();
        }
      )
  }
}
