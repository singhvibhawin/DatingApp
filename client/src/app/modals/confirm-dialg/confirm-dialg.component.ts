import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-confirm-dialg',
  templateUrl: './confirm-dialg.component.html',
  styleUrls: ['./confirm-dialg.component.css']
})
export class ConfirmDialgComponent implements OnInit{
  title = '';
  message = '';
  btnOKText = '';
  btnCancelText = '';
  result = false;

  constructor(public bsModalRef: BsModalRef) {}

  ngOnInit(): void {
    
  }

  confirm() {
    this.result = true;
    this.bsModalRef.hide();
  }

  decline() {
    this.bsModalRef.hide();
  }
}
