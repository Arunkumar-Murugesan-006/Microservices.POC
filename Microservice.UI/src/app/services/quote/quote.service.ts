import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observable, Subject } from 'rxjs';
import { QuoteModel } from 'src/app/models/quote/quote.model';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {

  API_URL: string = "https://localhost:7193/api/Quote";

  constructor(private _httpClient: HttpClient) { }

  form: FormGroup = new FormGroup(
    {
      quoteId: new FormControl(null),
      origin: new FormControl('', Validators.required),
      destination: new FormControl('', Validators.required),
      containerType: new FormControl('', Validators.required),
      quotePrice: new FormControl(''),
    }
  )

  initializeFormGroup()
  {
    this.form.setValue(
      {
        quoteId: 0,
        origin: '',
        destination: '',
        containerType: '',
        quotePrice: ''
      });
  }
  populateForm(quote: any)
  {
    this.form.setValue(quote);
  }
  getAllQuotes(): Observable<any> 
  {
    return this._httpClient.get(this.API_URL);
  }

  addQuote(quote: QuoteModel): Observable<any>
  {
    const httpOptions = 
    {
      headers: new HttpHeaders(
        {
          'Content-Type': 'application/json'
        }
      )
    };
    return this._httpClient.post(this.API_URL, quote, httpOptions);
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
