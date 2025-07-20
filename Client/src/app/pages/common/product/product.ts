import {Component, computed, inject, OnInit, signal} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Svg} from '../svg/svg';
import {ShoppingBag} from '../../../common/shopping-bag.service';
import {ProductData} from '../../../common/product-image.service';

@Component({
  selector: 'app-product',
  imports: [Svg],
  templateUrl: './product.html',
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

  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get('id');
  }
}
