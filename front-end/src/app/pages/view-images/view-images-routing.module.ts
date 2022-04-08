import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {ViewImagesComponent} from './view-images.component';

const routes: Routes = [
  {
    path: '',
    component: ViewImagesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ViewImagesRoutingModule { }
