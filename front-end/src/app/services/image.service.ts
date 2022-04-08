import {Injectable} from '@angular/core';
import {HttpClient, HttpErrorResponse, HttpResponse} from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import {catchError, tap} from 'rxjs/operators';
import {environment} from '../../environments/environment';
import {ImageData} from '../interfaces/image.interface';

@Injectable({providedIn: 'root'})
export class ImageService {
  constructor(private http: HttpClient) {
  }

  // Injectable fetch all images function
  fetchAllImages(): Observable<ImageData[]> {
    return this.http.get<ImageData[]>(`${environment.URL}/getAll`).pipe(
      catchError(this.handleError),
      tap(_ => console.log('Images fetched!')),
    );
  }

  // Injectable upload image function
  uploadImage(formData: FormData): Observable<HttpResponse<FormData>> {
    return this.http.post<FormData>(`${environment.URL}/Image/upload`,
      formData,
      {
        observe: 'response',
        responseType: 'json',
      }
    ).pipe(
      catchError(this.handleError),
      tap(_ => {
        console.log('Image successfully uploaded!');
      }),
    );
  }

  // Handle any http error responses
  handleError = (error: HttpErrorResponse) => {
    let errorMessage;
    if (error.error instanceof ErrorEvent) {
      errorMessage = `Error ${error.error.message}`;
    } else {
      errorMessage = `Error Code: ${error.status} \n Message: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}
