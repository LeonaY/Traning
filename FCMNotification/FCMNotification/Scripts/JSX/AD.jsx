
var ItemHeader = React.createClass({

    mixins: [TimeMixin],

    getDefaultProps () {
        return {
            text: '現正搶購中',
            expired: '',
            index: 0
        }
    },

    getInitialState () {
        return {
            timerId: 0,
            hours: "00",
            minutes: "00",
            seconds: "00",
            isExpired: false
        };
    },

    componentDidMount () {

        if (!this.state.isExpired) {
            this._onTimerStart(this.props.expired, 500);
        }
    },

    componentDidUpdate (prevProps, prevState) {

        if (this.state.isExpired) {
            this._onTimerPause(this.state.timerId);
        }

    },

    render: function () {

        var timerElem;

        if (this.state.isExpired) {
            timerElem = <span className="timer-finish">優惠結束</span>;
        }

        else {
            timerElem = <Timer hours={this.state.hours} minutes={this.state.minutes} seconds={this.state.seconds} />;
        }

        return (
            <header>
                {this.props.text} {timerElem}
            </header>);
}
});


var CountdownItemList = React.createClass({

    _afterChange (pageNumber) {
        this.props.updatePage(pageNumber + 1);
    },

    render () {

        var sliderSettings = {

            slidesToShow: 1,
            infinite: true,
            arrows: false,
            dots: false,
            centerMode: true,
            variableWidth: true,
            
            initialSlide: -1,
            autoplay: true,
            autoplaySpeed: 50,
            afterChange: this._afterChange
        };

        var productNodes = this.props.products.map(function (product, index) {

            product.listType = this.props.listType;

            var trackingDataProps = {
                'data-kanban-action': index + 1,
                'data-kanban-label': product.advertisementId
            };

            var productItem = function () {

                var productItemKey = 'countdownItem' + index;

                return (product.marketingPrice == 0 || product.finalPrice == 0)
                      ? (<ProductPhoneCall {...product} key={productItemKey} />)
                      : (<Product {...product} key={productItemKey } />);

}.call(this);

return (
    <div key={ 'countdownItem' + index } {...trackingDataProps}>
        <div className="countdown-item">
            <ItemHeader index={index} 
expired={product.period.expired} />
{productItem}
</div>
</div>
                );
}.bind(this));

return (
    <div className="countdown-list">
        <Slider {...sliderSettings}>{productNodes}</Slider>
    </div>
            );
}
});

var PageNumber = React.createClass({
    render () {
        return (
            <span className="pagination"><span className="current-page">1</span>/<span className="total-page">1</span></span>
            );
    }
});

var CountdownHeader = React.createClass({
    render () {
        return (
            <header>{this.props.header}{this.props.children}</header>
            );
}
});

var CountdownSale = React.createClass({

    getInitialState () {
        return {
            current: 1
        };
    },

    getDefaultProps () {
        return {
            isOnTv: true,
            isOnCountdownSale: false,
            showFlag: false,
            showFavoriteBtn: true,
            showDeleteBtn: false,
        }
    },

    _updatePage (pageNumber) {
        this.setState({ current : pageNumber})
    },

    render () {

        var trackingDataProps = {
            'data-kanban-category': this.props.trackingCategory
        };

        return (
            <div className="wrapper kanban-list">
                <CountdownItemList products={this.props.contents} listType={this.props.type} updatePage={this._updatePage} />
            </div>
        );
}
});

