import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { QuoteModel } from 'src/app/models/quote/quote.model';
import { NotificationService } from 'src/app/services/notification/notification.service';
import { QuoteService } from 'src/app/services/quote/quote.service';

@Component({
  selector: 'app-quote',
  templateUrl: './quote.component.html',
  styleUrls: ['./quote.component.css']
})
export class QuoteComponent implements OnInit {

  constructor(public _service: QuoteService, 
              public _dialogRef: MatDialogRef<QuoteComponent>,
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
    var quote = new QuoteModel();
    quote.origin = this._service.form.value["origin"];
    quote.destination = this._service.form.value["destination"];
    quote.containerType = this._service.form.value["containerType"];
    quote.quotePrice = this._service.form.value["quotePrice"];

    this._service.addQuote(quote)
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
