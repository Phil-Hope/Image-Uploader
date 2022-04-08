import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {ViewImagesRoutingModule} from './view-images-routing.module';
import {ViewImagesComponent} from './view-images.component';
import {ImageService} from '../../services/image.service';
import {HttpClientModule} from '@angular/common/http';
import {BsModalService} from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [ViewImagesComponent],
  imports: [CommonModule, ViewImagesRoutingModule, HttpClientModule],
  providers: [ImageService, BsModalService]
})
export class ViewImagesModule { }

