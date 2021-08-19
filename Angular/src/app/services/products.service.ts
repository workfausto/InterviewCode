import { Injectable, Inject } from '@angular/core';
import {HttpClient} from '@angular/common/http'

import { Observable } from 'rxjs';
import {map} from   'rxjs/operators'

import { Product } from '../Interfaces/product.interface';

//provider
@Injectable()
export class ProductsService {
    constructor(private http: HttpClient,@Inject('api') private api: string) {}

    GetProducts(): Observable<Product[]> {
        return this.http.get(`${this.api}GetProducts`).pipe(
            map(response => response as Product[]));
    }

    GetProductByID(ProductId:number): Observable<Product> {
        return this.http.get(`${this.api}GetProductByID/${ProductId}`).pipe(
            map(response => response as Product));
    }

    InsertProduct(product:Product): Observable<any> {
        return this.http.post(`${this.api}InsertProduct`,product).pipe(
            map(response => response));
    }

    DeleteProduct(ProductId:number): Observable<any> {
        return this.http.delete(`${this.api}DeleteProduct/${ProductId}`).pipe(
            map(response => response));
    }

    UpdateProduct(product:Product): Observable<any> {
        return this.http.put(`${this.api}UpdateProduct`,product).pipe(
            map(response => response));
    }
}