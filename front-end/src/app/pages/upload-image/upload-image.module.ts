import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UploadImageRoutingModule} from './upload-image-routing.module';
import {UploadImageComponent} from './upload-image.component';
import {ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {ImageService} from '../../services/image.service';
import {BsModalService} from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [UploadImageComponent],
  imports: [
    CommonModule,
    UploadImageRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [ImageService, BsModalService]
})
export class UploadImageModule { }
