import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, Subject } from 'rxjs';
import { ProductModel } from 'src/app/models/product/product.model';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  API_URL: string = "https://localhost:7291/api/Product";

  constructor(private _httpClient: HttpClient) { }

  form: FormGroup = new FormGroup(
    {
      productId: new FormControl(null),
      origin: new FormControl('', Validators.required),
      destination: new FormControl('', Validators.required),
      containerType: new FormControl('', Validators.required),
      price: new FormControl(''),
      volume: new FormControl('')
    }
  )

  initializeFormGroup()
  {
    this.form.setValue(
      {
        productId: 0,
        origin: '',
        destination: '',
        containerType: '',
        price: '',
        volume: ''
      });
  }

  populateForm(product: any)
  {
    this.form.setValue(product);
  }

  getAllProducts(): Observable<any> 
  {
    return this._httpClient.get(this.API_URL);
  }

  addProduct(product: ProductModel): Observable<any>
  {
    const httpOptions = 
    {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }
      )
    };
    return this._httpClient.post(this.API_URL, product, httpOptions);
  }

  deleteProduct(id: number): Observable<number>
  {
    const httpOptions = 
    {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }
      )
    };
    return this._httpClient.delete<number>(this.API_URL + "/" + id, httpOptions);
  }

  private _listners = new Subject<any>();
  listen(): Observable<any>
  {
    return this._listners.asObservable();
  }
  filter(filterby: string)
  {
    this._listners.next(filterby);
  }
}
