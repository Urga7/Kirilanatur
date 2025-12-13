export const ProductPriceId: Record<string, string> = {
  ['1_37']: 'price_1SdrvcRsVXTbA9waKNOlwY9T',
  ['1_38']: 'price_1SdVeORsVXTbA9waPrcQ4Aul',
  ['1_39']: 'price_1SdrtQRsVXTbA9wa6rAsZfUc',
  ['1_40']: 'price_1SdruLRsVXTbA9walerqZmGm',
  ['1_41']: 'price_1SdrvCRsVXTbA9waLLZW78wX',

  ['2_37']: 'price_1SdWBCRsVXTbA9waFT9r2XJR',

  ['3_37']: 'price_1SdWBZRsVXTbA9waO6CqxNzq',
}

export function GetProductPriceId(productId: string, size: number) {
  return ProductPriceId[`${productId}_${size}`]
}
