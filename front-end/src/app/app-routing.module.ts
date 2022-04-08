import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'upload',
    pathMatch: 'full'
  },
  {
    path: 'upload',
    loadChildren: () => import('./pages/upload-image/upload-image.module')
      .then(m => m.UploadImageModule)
  },
  {
    path: 'view',
    loadChildren: () => import('./pages/view-images/view-images.module')
      .then(m => m.ViewImagesModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
