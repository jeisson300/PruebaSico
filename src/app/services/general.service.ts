import { EventEmitter, Injectable } from '@angular/core';
import {
  EventStudent,
  ResponseApi,
  ResponseApiGet,
  Student,
} from '../interface/student.interface';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class GeneralServices {
  constructor(private _http: HttpClient) {}
  public eventSubject = new Subject<EventStudent>();
  openModal = this.eventSubject.asObservable();

  public Students: Student[] = [
    {
      identification: 0,
      name: '',
      lastName: '',
      email: '',
    },
  ];

  public hanldeModal(event: EventStudent) {
    this.eventSubject.next(event);
  }

  public sendPetionGet(url: string): Promise<any> {
    return new Promise((resolve, reject) => {
      this._http.get<ResponseApiGet>(url).subscribe(
        (resp) => {
          resolve(resp.data);
        },
        (error) => {
          reject(error);
        }
      );
    });
  }
  public sendPetionPost(url: string, body: any): Promise<any> {
    return new Promise((resolve, reject) => {
      this._http.post<ResponseApi>(url, body).subscribe(
        (resp) => {
          resolve(resp.data);
        },
        (error) => {
          reject(error);
        }
      );
    });
  }
  public sendPetionDelete(url: string) {
    return new Promise((resolve, reject) => {
      this._http.delete<ResponseApi>(url).subscribe(
        (resp) => {
          resolve(resp.data);
        },
        (error) => {
          reject(error);
        }
      );
    });
  }
}
