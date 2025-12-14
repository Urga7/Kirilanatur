import {Component, computed, inject, OnInit, signal} from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import {Svg} from '../svg/svg';
import {ShoppingBag} from '../../../common/shopping-bag.service';
import { trigger, transition, style, animate } from '@angular/animations';
import { ProductRepository, ProductWithPrices } from '../../../common/product-repository';

export interface ProductImage {
  path: string
  alt: string
  type: ImageType
}

export enum ImageType {
  Default,
  UsageExample
}

export interface ShoeSize {
  size: number
  priceId: string
}

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
  protected readonly route = inject(ActivatedRoute)
  protected readonly productRepository = inject(ProductRepository)
  protected readonly product = signal<ProductWithPrices | undefined>(undefined)
  protected images = signal<ProductImage[]>([])
  protected shoeSizes = signal<ShoeSize[]>([])
  protected readonly selectedShoeSize = signal<ShoeSize | undefined>(undefined)
  protected readonly selectedImage = signal<ProductImage | undefined>(undefined)
  protected readonly availableImages = computed(() => {
    const selectedImagePath = this.selectedImage()?.path
    return this.images().filter(pi => pi.path !== selectedImagePath)
  })
  protected readonly isAddingItem = signal(false)

  async ngOnInit() {
    const productName = this.route.snapshot.paramMap.get('name');
    if (productName === null) {
      throw Error('Product name not found in route')
    }

    const product = await this.productRepository.getProductWithPricesByName(productName)
    if (product === undefined) {
      throw Error(`Product with name ${productName} not found`)
    }

    this.product.set(product)
    const images = this.extractImages(product)
    this.images.set(images)
    this.selectedImage.set(images[1])
    const shoeSizes = this.extractShoeSizes(product)
    this.shoeSizes.set(shoeSizes)
    this.selectedShoeSize.set(shoeSizes[2])
  }

  private extractImages(product: ProductWithPrices) {
    const regularProductImages: ProductImage[] = product.images
      .map(image => ({path: image, alt: image, type: ImageType.Default}))

    const exampleUsageProductImage: ProductImage = {
      path: product.exampleUsageImage,
      alt: product.exampleUsageImage,
      type: ImageType.UsageExample
    }

   return [...regularProductImages, exampleUsageProductImage]
  }

  private extractShoeSizes(product: ProductWithPrices) {
    return product.prices
      .map<ShoeSize>(price => ({size: price.size, priceId: price.id}))
  }

  protected addItemToShoppingBag() {
    const product = this.product()
    const selectedShoeSize = this.selectedShoeSize()
    if (this.isAddingItem() || !product || selectedShoeSize === undefined) {
      return
    }

    this.shoppingBag.addItem(product, selectedShoeSize)
    this.isAddingItem.set(true)
    setTimeout(() => { this.isAddingItem.set(false) }, 1200)
  }

  protected ImageType = ImageType;
}
