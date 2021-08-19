import { OnInit, ViewChild } from '@angular/core';
import { Component } from '@angular/core';

import { Product } from 'src/app/Interfaces/product.interface';
import { ProductsService } from 'src/app/services/products.service';
import { ProductFormComponent } from '../product-form/product-form.component';

declare var $: any;

//declaration
@Component({
    selector: 'app-products',
    styleUrls: ['products.component.css'],
    templateUrl: 'products.component.html'
})
export class ProductsComponent implements OnInit {
    lstProducts:Product[];

    deleteProduct:Product;

    loading:boolean=false;

    @ViewChild(ProductFormComponent) productForm: ProductFormComponent;

    constructor(private productService:ProductsService) {}
    
    ngOnInit():void{
        this.refreshList();
    }

    refreshList(){
        this.productService.GetProducts().toPromise().then(res=>{
            this.lstProducts=res;
        });
    }

    update(row:Product){
        this.loading = true;
        this.productService.GetProductByID(row.Id).toPromise()
        .then(res  =>{
            this.productForm.loadData(res ,true);
        })
        .catch(err=>{
            alert(err);
        })
        .finally(()=>{
            this.loading = false;
        });
    }

    promptDelete(row:Product){
        this.deleteProduct = row;
        $("#deletePrompt").modal("show");
    }

    dismissPrompt(){
        $("#deletePrompt").modal("hide");
    }

    promptInsert(){
        this.productForm.loadData({Id:0, Name:"", Description:"", Price:0,AgeRestriction:undefined,Company:""},false);
    }

    edit(data:Product){
        this.productService.UpdateProduct(data).toPromise()
        .then(res=>{
            if(res.error){
                alert(res.message);
            }else{
                this.refreshList();
                this.productForm.dismissModal();
            }
            console.log(res);
        })
        .catch(err=>{
            alert(err);
        });
    }

    insert(data:Product){
        this.productService.InsertProduct(data).toPromise()
        .then(res=>{
            if(res.error){
                alert(res.message);
            }else{
                this.refreshList();
                this.productForm.dismissModal();
            }
            
            console.log(res);
        })
        .catch(err=>{
            alert(err);
        });
    }

    delete(){
        this.productService.DeleteProduct(this.deleteProduct.Id).toPromise()
        .then(res=>{
            if(res.error){
                alert(res.message);
            }else{
                this.refreshList();
                $("#deletePrompt").modal("hide");
            }
            console.log(res);
        })
        .catch(err=>{
            alert(err);
        });
    }
    
}