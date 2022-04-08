import {Component, OnInit, TemplateRef} from '@angular/core';
import {ImageService} from '../../services/image.service';
import {ImageData} from '../../interfaces/image.interface';
import {Observable} from 'rxjs';
import {tap} from 'rxjs/operators';
import {BsModalService, BsModalRef} from 'ngx-bootstrap/modal';
import {environment} from '../../../environments/environment';

@Component({
  selector: 'app-view-images',
  templateUrl: './view-images.component.html',
  styleUrls: ['./view-images.component.css']
})
export class ViewImagesComponent implements OnInit {

  modalRef?: BsModalRef;
  imageData?: ImageData[];
  imageUrl?: string;

  constructor(
    private imageService: ImageService,
    private modalService: BsModalService
  ) {
  }

  ngOnInit(): void {
    this.getImageData().subscribe((data: ImageData[]) => this.imageData = data);
  }

  openModal = (template: TemplateRef<any>) => {
    this.modalRef = this.modalService.show(template);
  }

  setImageUrl = (url: string) => {
    this.imageUrl = environment.URL + '/Resources/Images/' + url;
    console.log(this.imageUrl);
  }

  getImageData(): Observable<ImageData[]> {
    return this.imageService.fetchAllImages()
      .pipe(
        tap(async (res) => {
          console.log(res);
        })
      );
  }
}
