﻿// /*******************************************************************************
//  * Copyright 2012-2018 Esri
//  *
//  *  Licensed under the Apache License, Version 2.0 (the "License");
//  *  you may not use this file except in compliance with the License.
//  *  You may obtain a copy of the License at
//  *
//  *  http://www.apache.org/licenses/LICENSE-2.0
//  *
//  *   Unless required by applicable law or agreed to in writing, software
//  *   distributed under the License is distributed on an "AS IS" BASIS,
//  *   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  *   See the License for the specific language governing permissions and
//  *   limitations under the License.
//  ******************************************************************************/

using Android.App;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Esri.ArcGISRuntime.Mapping;

namespace Esri.ArcGISRuntime.Toolkit.UI.Controls
{
    internal class BookmarkItemView : LinearLayout
    {
        private readonly TextView _textView;

        internal BookmarkItemView(Context context)
            : base(context)
        {
            Orientation = Orientation.Horizontal;
            LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            SetGravity(GravityFlags.CenterVertical | GravityFlags.FillHorizontal);

            _textView = new TextView(context)
            {
                LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent)
            };

            TypedValue listItemHeightValue = new TypedValue();
            Application.Context.Theme.ResolveAttribute(Android.Resource.Attribute.ListPreferredItemHeight, listItemHeightValue, true);
            SetMinimumHeight((int)listItemHeightValue.GetDimension(Resources.DisplayMetrics));

            TypedValue listItemLeftMarginValue = new TypedValue();
            Application.Context.Theme.ResolveAttribute(Android.Resource.Attribute.ListPreferredItemPaddingStart, listItemLeftMarginValue, true);

            TypedValue listItemRightMarginValue = new TypedValue();
            Application.Context.Theme.ResolveAttribute(Android.Resource.Attribute.ListPreferredItemPaddingEnd, listItemRightMarginValue, true);

            SetPadding((int)listItemLeftMarginValue.GetDimension(Resources.DisplayMetrics), 0, (int)listItemRightMarginValue.GetDimension(Resources.DisplayMetrics), 0);

            _textView.Gravity = GravityFlags.CenterVertical | GravityFlags.FillHorizontal;
            AddView(_textView);
        }

        internal void Update(Bookmark info)
        {
            _textView.Text = info?.Name;
        }
    }
}