import { Injectable } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ConfirmDialgComponent } from '../modals/confirm-dialg/confirm-dialg.component';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConfirmService {
  bsModalRef?: BsModalRef<ConfirmDialgComponent>;

  constructor(private modalService: BsModalService) { }

  confirm(
    title = 'Confirmation',
    message = 'Are you sure you want do this this?',
    btnOKText = 'Ok',
    btnCancelText = 'Cancel',
  ): Observable<boolean> {
    const config = {
      initialState: {
        title,
        message,
        btnOKText,
        btnCancelText
      }
    }
    this.bsModalRef = this.modalService.show(ConfirmDialgComponent, config);
    return this.bsModalRef.onHidden!.pipe(
      map(() => {
        return this.bsModalRef?.content?.result
      })
    )
  }
}
