import {Component} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {ImageService} from '../../services/image.service';
import {HttpEventType} from '@angular/common/http';

@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.css']
})
export class UploadImageComponent {

  isLoading = false;

  form = new FormGroup({
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });

  constructor(
    public imageService: ImageService,
  ) { }

  onFileChange(event: any): void {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.form.patchValue({
        fileSource: file
      });
    }
  }

  uploadImage(): void {
    if (this.form.valid) {
      const formData = new FormData();
      formData.append('file', this.form.get('fileSource')?.value);
      this.imageService.uploadImage(formData)
        .subscribe((res) => {
          this.isLoading = res.type !== HttpEventType.Response;
          if (res.status === 200) {
           window.alert('Image Uploaded!');
          }
        });
      this.form.reset();
    }
  }

}
