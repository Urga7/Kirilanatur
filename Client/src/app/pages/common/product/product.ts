import {Component, computed, inject, OnInit, signal} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Svg} from '../svg/svg';
import {ShoppingBag, ShoppingBagItem} from '../../../common/shopping-bag.service';
import {ProductData} from '../../../common/product-image.service';
import { trigger, transition, style, animate } from '@angular/animations';

@Component({
  selector: 'app-product',
  imports: [Svg],
  templateUrl: './product.html',
  animations: [
    trigger('fadeInOut', [
      transition(':enter', [
        style({ opacity: 0 }),
        animate('200ms ease-in', style({ opacity: 1 }))
      ]),
      transition(':leave', [
        animate('200ms ease-out', style({ opacity: 0 }))
      ])
    ])
  ]
})
export class Product implements OnInit {
  protected readonly shoppingBag = inject(ShoppingBag)
  protected readonly productData = inject(ProductData)
  protected readonly route = inject(ActivatedRoute)
  protected productId: string | null = null
  protected readonly imageIds = ['a', 'b', 'c', 'd']
  protected readonly shoeSizes: number[] = [37, 38, 39, 40, 41]
  protected readonly selectedShoeSize = signal(39)
  protected readonly selectedImageId = signal('a')
  protected readonly availableImageIds = computed(() => {
    return this.imageIds.filter(identifier => identifier !== this.selectedImageId())
  })
  protected readonly selectedImageUrl = computed(() => this.productData.imageUrl(this.productId!, this.selectedImageId()))
  protected readonly selectedImageAlt = computed(() => {
    return `product-${this.productId}${this.selectedImageId()}`
  })
  protected readonly isAddingItem = signal(false)

  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get('id');
  }

  addItemToShoppingBag() {
    if (this.isAddingItem()) return

    const item: ShoppingBagItem = {
      productId: this.productId ?? "",
      size: this.selectedShoeSize(),
      quantity: 1
    }

    this.shoppingBag.addItem(item)
    this.isAddingItem.set(true)

    setTimeout(() => {
      this.isAddingItem.set(false)
    }, 1500)
  }

}
