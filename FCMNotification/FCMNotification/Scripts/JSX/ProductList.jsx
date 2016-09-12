var ProductList = React.createClass({

    getDefaultProps () {
        return {
            isOnTv: false, 
            isOnCountdownSale: false,
            isOnPromotion: false,
            showFlag: false,
            showFavoriteBtn: false,
            showDeleteBtn: false,
            handleClick: null
        }
    },

    render () {

        var products = this.props.contents.map(function (sourceProduct, index) {

            var product = _.cloneDeep(sourceProduct);

            product.listType = this.props.type;
            product.index = index;
            product = utilityJS.extend({}, this.props, product);

            var key = "productItem_" + ((this.props.isOnPromotion) ? index : product.id);

            return (
                <Product {...product} key={key} />
                );

}.bind(this));

var listProps = {};

if (this.props.handleClick)
    listProps.onClick = this.props.handleClick;


return (
    <div className="product-list" {...listProps}>
        {products}
    </div>
        );
}
});