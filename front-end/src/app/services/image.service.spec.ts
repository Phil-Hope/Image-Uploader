import { ImageService } from './image.service';

describe('ImageService', () => {
  // tslint:disable-next-line:prefer-const
  let service: ImageService;


  it('should run #fetchAllImages()', async () => {
    service.fetchAllImages();
    expect(service.fetchAllImages()).toHaveBeenCalled();
  });

  it('should run #uploadImage()', async () => {
    const formData = new FormData();
    service.uploadImage(formData);
    expect(service.uploadImage(formData)).toHaveBeenCalled();
  });

});
