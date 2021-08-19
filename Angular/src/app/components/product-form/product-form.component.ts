import { EventEmitter, isDevMode } from '@angular/core';
import { Component, Input, Output } from '@angular/core';
import { Product } from 'src/app/Interfaces/product.interface';
import { FormsModule, NgForm } from '@angular/forms';

declare var $: any;

//declaration
@Component({
    selector: 'product-form',
    styleUrls: ['product-form.component.css'],
    templateUrl: 'product-form.component.html'
})
export class ProductFormComponent {

    formData:Product = {Id:0, Name:"", Description:"", Price:0,AgeRestriction:0,Company:""};
    isEditing:boolean;

    @Output() editSubmit:EventEmitter<Product> = new EventEmitter<Product>();

    @Output() insertSubmit:EventEmitter<Product> = new EventEmitter<Product>();

    constructor() {
        $("#form_modal").modal("show");
    }

    onSubmit(form:NgForm){
        if(this.isEditing){
            console.log("submitting")
            this.editSubmit.emit(this.formData);
        }else{
            console.log("submitting2")
            this.insertSubmit.emit(this.formData)
        }
        form.resetForm();
    }

    loadData(data:Product, submitMode:boolean){
        this.isEditing = submitMode;
        this.formData = {...data};
        $("#form_modal").modal("show");
    }

    dismissModal(){
        $("#form_modal").modal("hide");
    }

    get validAge(){
        return ((this.formData.AgeRestriction >= 0 && this.formData.AgeRestriction <= 100) || !this.formData.AgeRestriction);
    }

    get validPrice(){
        return (this.formData.Price >= 1 && this.formData.Price <= 1000);
    }
}